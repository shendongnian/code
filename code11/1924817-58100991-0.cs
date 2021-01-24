 chsarp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Renci.SshNet;
using Renci.SshNet.Common;
namespace Example
{
    public class Log
    {
        public static void Verbose(string message) =>
            Console.WriteLine(message);
        public static void Error(string message) =>
            Console.WriteLine(message);
    }
    public static class StringExt
    {
        public static string StringBeforeLastRegEx(this string str, Regex regex)
        {
            var matches = regex.Matches(str);
            
            return matches.Count > 0
                ? str.Substring(0, matches.Last().Index)
                : str;
            
        }
        public static bool EndsWithRegEx(this string str, Regex regex)
        {
            var matches = regex.Matches(str);
            
            return 
                matches.Count > 0 &&
                str.Length == (matches.Last().Index + matches.Last().Length);
        }
    }
    
    
    public class Ssh
    {
        SshClient sshClient;
        ShellStream shell;
        string pwd = "";
        string lastCommand = "";
        
        static Regex prompt = new Regex("[a-zA-Z0-9_.-]*\\@[a-zA-Z0-9_.-]*\\:\\~[#$] ", RegexOptions.Compiled);
        static Regex pwdPrompt = new Regex("password for .*\\:", RegexOptions.Compiled);
        static Regex promptOrPwd = new Regex(Ssh.prompt + "|" + Ssh.pwdPrompt);
        
        public void Connect(string url, int port, string user, string pwd)
        {
            Log.Verbose($"Connect Ssh: {user}@{pwd}:{port}");
            
            var connectionInfo =
                new ConnectionInfo(
                    url,
                    port,
                    user,
                    new PasswordAuthenticationMethod(user, pwd));
            this.pwd = pwd;
            this.sshClient = new SshClient(connectionInfo);
            this.sshClient.Connect();
            
            var terminalMode = new Dictionary<TerminalModes, uint>();
            terminalMode.Add(TerminalModes.ECHO, 53);
            
            this.shell = this.sshClient.CreateShellStream("", 0, 0, 0, 0, 4096, terminalMode);
            
            try
            {
                this.Expect(Ssh.prompt);
            }
            catch (Exception ex)
            {
                Log.Error("Exception - " + ex.Message);
                throw;
            }
        }
        public void Disconnect()
        {
            Log.Verbose($"Ssh Disconnect");
            
            this.sshClient?.Disconnect();
            this.sshClient = null;
        }
        void Write(string commandLine)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Log.Verbose("> " + commandLine);
            Console.ResetColor(); 
                
            this.lastCommand = commandLine;
            
            this.shell.WriteLine(commandLine);
        }
        string Expect(Regex expect, double timeoutSeconds = 60.0)
        {
            var result = this.shell.Expect(expect, TimeSpan.FromSeconds(timeoutSeconds));
            if (result == null)
            {
                throw new Exception($"Timeout {timeoutSeconds}s executing {this.lastCommand}");
            }
            
            result = result.Contains(this.lastCommand) ? result.StringAfter(this.lastCommand) : result;
            result = result.StringBeforeLastRegEx(Ssh.prompt);
            result = result.Trim();
           
            result.GetLines().ForEach(x => Log.Verbose(x));
            return result;
        }
        public string Execute(string commandLine, double timeoutSeconds = 30.0)
        {
            Exception exception = null;
            var result = "";
            var errorMessage = "failed";
            var errorCode = "exception";
            
            try
            {
                this.Write(commandLine);
                result = this.Expect(Ssh.promptOrPwd);
                if (result.EndsWithRegEx(pwdPrompt))
                {
                    this.Write(this.pwd);
                    this.Expect(Ssh.prompt);
                }
                this.Send("echo $?");
                errorCode = this.Expect(Ssh.prompt);
                if (errorCode == "0")
                {
                    return result;    
                }
                else if (result.Length > 0)
                {
                    errorMessage = result;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                errorMessage = ex.Message;
            }
            
            throw new Exception($"Ssh error: {errorMessage}, code: {errorCode}, command: {commandLine}", exception);
        }
    }
}
