    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.IO;
    
    namespace TeaTimer
    {
    	/// <summary>
    	/// MCIPlayer is based off code by Slain.
    	/// Found here: http://www.sadeveloper.net/Articles_View.aspx?articleID=212
    	/// </summary>
    	public class MCIPlayer
    	{
    		private static readonly string sAlias="TeaTimerAudio";
    
    		[DllImport("winmm.dll")]
    		private static extern long mciSendString(string strCommand,StringBuilder strReturn,int iReturnLength, IntPtr hwndCallback);
    		[DllImport("Winmm.dll")]
    		private static extern long PlaySound(byte[] data, IntPtr hMod, UInt32 dwFlags);
    
    		public static void Play(string sFile)
    		{
    			_Open(sFile);
    			_Play();
    		}
    		public static void Stop() 
    		{
    			_Close();
    		}
    
    		private static void _Open(string sFileName)
    		{
    			if(_Status()!="")
    				_Close();
    
    			string sCommand = "open \"" + sFileName + "\" alias "+sAlias;
    			mciSendString(sCommand, null, 0, IntPtr.Zero);
    		}
    
    		private static void _Close()
    		{
    			string sCommand = "close "+sAlias;
    			mciSendString(sCommand, null, 0, IntPtr.Zero);
    		}
    
    		private static void _Play()
    		{
    			string sCommand = "play "+sAlias;
    			mciSendString(sCommand, null, 0, IntPtr.Zero);
    		}
    
    		private static string _Status()
    		{
    			StringBuilder sBuffer = new StringBuilder(128);
    			mciSendString("status "+sAlias+" mode", sBuffer, sBuffer.Capacity, IntPtr.Zero);
    			return sBuffer.ToString();
    		}
    	}
    }
