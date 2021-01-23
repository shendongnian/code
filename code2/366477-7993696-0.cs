	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Windows.Forms;
	using System.Windows.Input;
	using System.Threading;
	namespace some.any
	{
		public class ANY_CLASS
		{
		static STAKeyBoard mSTAKeyBoard = new STAKeyBoard();
		
		public static short ThisIsCalledByAnExternalProgram()
		{
			try
			{
				if (mSTAKeyBoard.IsKeyDown(Key.LeftAlt))
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
			catch (Exception e)
			{
					MessageBox.Show(e.ToString());
					return 2;
			 }
		}
		
		class STAKeyBoard
		{
			private Thread mKeyBoardReadThread = null;
			private Boolean mKeyState = false;
			private Key mKeyOfInterest;
			private string running = "ONLY ONE REQUEST";
			public Boolean IsKeyDown(Key KeyOfInterest)
			{
				lock (running)
				{
					mKeyOfInterest = KeyOfInterest;
					mKeyBoardReadThread = new Thread(new ThreadStart(GetKeyState));
					mKeyBoardReadThread.SetApartmentState(ApartmentState.STA);
					mKeyBoardReadThread.Start();
					mKeyBoardReadThread.Join(1000);
					mKeyBoardReadThread.Abort();
					mKeyBoardReadThread = null;
					return mKeyState;
				}
			}
			private void GetKeyState()
			{
				mKeyState = Keyboard.IsKeyDown(mKeyOfInterest);
			}
		}
	}
