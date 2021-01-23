		/// <summary>
		/// Sends keystrokes to the specified window
		/// </summary>
		/// <param name="hWnd">Window's hWnd</param>
		/// <param name="keys">String of keys to send</param>
		/// <returns>Returns number of keystrokes sent, -1 if an error occurs</returns>
		public int SendKeys(int hWnd, string keys)
		{
			if( hWnd <= 0 || keys.Length == 0 )
				return -1;
			int ret = 0, i = 0;
			System.Text.StringBuilder str = new System.Text.StringBuilder(keys.ToUpper());
			str.Replace(Convert.ToChar("`"), Convert.ToChar(0xC0));
			str.Replace(Convert.ToChar("~"), Convert.ToChar(0xC0));
			str.Replace(Convert.ToChar("-"), Convert.ToChar(0xBD));
			str.Replace(Convert.ToChar("="), Convert.ToChar(0xBB));
			str.Replace("{TAB}", Convert.ToChar(0x9).ToString());
			str.Replace("{ENTER}", Convert.ToChar(0xD).ToString());
			str.Replace("{ESC}", Convert.ToChar(0x1B).ToString());
			str.Replace("{F5}", Convert.ToChar(0x74).ToString());
			str.Replace("{F12}", Convert.ToChar(0x7B).ToString());
			str.Replace("{SHIFTD}", Convert.ToChar(0xC1).ToString());
			str.Replace("{SHIFTU}", Convert.ToChar(0xC2).ToString());
			for( int ix = 1; ix <= str.Length; ++ix )
			{
				char chr = str[i];
				if( Convert.ToInt32(chr) == 0xC1 )
				{
					_PostMessage(hWnd, 0x100, 0x10, 0x002A0001);
					_PostMessage(hWnd, 0x100, 0x10, 0x402A0001);
					Thread.Sleep(1);
				}
				else if( Convert.ToInt32(chr) == 0xC2 )
				{
					_PostMessage(hWnd, 0x101, 0x10, 0xC02A0001);
					Thread.Sleep(1);
				}
				else
				{
					ret = _MapVirtualKey(Convert.ToInt32(chr), 0);
					if( _PostMessage(hWnd, 0x100, Convert.ToInt32(chr), MakeLong(1, ret)) == 0 )
						return -1;
						Thread.Sleep(1);
					if( _PostMessage(hWnd, 0x101, Convert.ToInt32(chr), (MakeLong(1, ret) + 0xC0000000)) == 0 )
						return -1;
				}
				i++;
			}
			return i;
		}
