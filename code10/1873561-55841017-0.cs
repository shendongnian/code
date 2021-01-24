    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Management.Automation;
    using System.Management.Automation.Host;
    using System.Management.Automation.Runspaces;
    using System.Security;
    namespace CustomHostExample
    {
        public static class Program
        {
            public static void Main()
            {
                var host = new CustomPSHost();
                using (Runspace rs = RunspaceFactory.CreateRunspace(host))
                using (PowerShell pwsh = PowerShell.Create())
                {
                    rs.Open();
                    pwsh.Runspace = rs;
                    pwsh.AddCommand("Read-Host").Invoke();
                }
            }
        }
        public class CustomPSHost : PSHost
        {
            public override string Name => "Custom Host";
            public override Version Version => new Version(1, 0, 0, 0);
            public override Guid InstanceId { get; } = Guid.NewGuid();
            public override PSHostUserInterface UI { get; } = new CustomPSHostUserInterface();
            public override CultureInfo CurrentCulture => CultureInfo.CurrentCulture;
            public override CultureInfo CurrentUICulture => CultureInfo.CurrentUICulture;
            public override void EnterNestedPrompt()
                => throw new NotImplementedException();
            public override void ExitNestedPrompt()
                => throw new NotImplementedException();
            public override void NotifyBeginApplication()
                => throw new NotImplementedException();
            public override void NotifyEndApplication()
                => throw new NotImplementedException();
            public override void SetShouldExit(int exitCode)
                => throw new NotImplementedException();
        }
        public class CustomPSHostUserInterface : PSHostUserInterface
        {
            public override PSHostRawUserInterface RawUI { get; } = new CustomPSHostRawUserInterface();
            public override string ReadLine()
            {
                return Console.ReadLine();
            }
            public override Dictionary<string, PSObject> Prompt(
                string caption,
                string message,
                Collection<FieldDescription> descriptions)
                => throw new NotImplementedException();
            public override int PromptForChoice(
                string caption,
                string message,
                Collection<ChoiceDescription> choices,
                int defaultChoice)
                => throw new NotImplementedException();
            public override PSCredential PromptForCredential(
                string caption,
                string message,
                string userName,
                string targetName,
                PSCredentialTypes allowedCredentialTypes,
                PSCredentialUIOptions options)
                => throw new NotImplementedException();
            public override PSCredential PromptForCredential(
                string caption,
                string message,
                string userName,
                string targetName)
                => throw new NotImplementedException();
            public override SecureString ReadLineAsSecureString()
                => throw new NotImplementedException();
            public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
                => throw new NotImplementedException();
            public override void Write(string value)
                => throw new NotImplementedException();
            public override void WriteDebugLine(string message)
                => throw new NotImplementedException();
            public override void WriteErrorLine(string value)
                => throw new NotImplementedException();
            public override void WriteLine(string value)
                => throw new NotImplementedException();
            public override void WriteProgress(long sourceId, ProgressRecord record)
                => throw new NotImplementedException();
            public override void WriteVerboseLine(string message)
                => throw new NotImplementedException();
            public override void WriteWarningLine(string message)
                => throw new NotImplementedException();
        }
        public class CustomPSHostRawUserInterface : PSHostRawUserInterface
        {
            public override ConsoleColor BackgroundColor
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public override Size BufferSize
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public override Coordinates CursorPosition
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public override int CursorSize
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public override ConsoleColor ForegroundColor
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public override Coordinates WindowPosition
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public override Size WindowSize
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public override string WindowTitle
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public override bool KeyAvailable
                => throw new NotImplementedException();
            public override Size MaxPhysicalWindowSize
                => throw new NotImplementedException();
            public override Size MaxWindowSize
                => throw new NotImplementedException();
            public override void FlushInputBuffer()
                => throw new NotImplementedException();
            public override BufferCell[,] GetBufferContents(Rectangle rectangle)
                => throw new NotImplementedException();
            public override KeyInfo ReadKey(ReadKeyOptions options)
                => throw new NotImplementedException();
            public override void ScrollBufferContents(
                Rectangle source,
                Coordinates destination,
                Rectangle clip,
                BufferCell fill)
                => throw new NotImplementedException();
            public override void SetBufferContents(Coordinates origin, BufferCell[,] contents)
                => throw new NotImplementedException();
            public override void SetBufferContents(Rectangle rectangle, BufferCell fill)
                => throw new NotImplementedException();
        }
    }
