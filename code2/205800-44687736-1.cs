	using System.Windows.Forms;
	static ImmutableDictionary<char, Keys> CharVKeyLookup;
	static void PopulateVKeyCharDictionary(){
		var keyboardStateNormal = new byte[255]; //All keys up
		var keyboardStateShift = new byte[255];
		keyboardStateShift[(int)Keys.ShiftKey] = 0x80;
		var charlookup = new Dictionary<char, Keys>();
		for (var i = 1; i < (int) Keys.OemClear; i++){
			var keys = (Keys) i;
			//Verbose condition to ignore unnecessary conversions - probably a quicker way e.g. statically
			if (keys == Keys.Enter || keys == Keys.Tab || keys == Keys.Space
					|| (keys >= Keys.D0 && keys <= Keys.D9)
					|| (keys >= Keys.A && keys <= Keys.Z)
					|| (keys >= Keys.Multiply && keys <= Keys.Divide)
					|| (keys >= Keys.Oem1 && keys <= Keys.Oem102)){
				var normal = KeyCodeToUnicode(keys);
				var shift = KeyCodeToUnicode(keys, true);
				if (normal.Item2 == 1) //Ignore wierdos - extend this if you need it
					charlookup[normal.Item1[0]]=keys;
				if (shift.Item2 ==1)
					charlookup[shift.Item1[0]]=keys|Keys.Shift; //Incl shift mod
			}
		}
        charlookup['\n'] =  Keys.Return;
        charlookup['\r'] = Keys.Return;
		CharVKeyLookup = charlookup.ToImmutableDictionary();
	}
	/// <returns>string if it exists and return code. -1=dead char, 0=no translation, 1=1 char, 2=special char </returns>
	public static Tuple<string, int> KeyCodeToUnicode(Keys key, byte[] keyboardState){
		var scanCode = MapVKToScanCode(key);
		var result = new StringBuilder(10,10);
		var language = InputLanguage.CurrentInputLanguage.Handle;//Or other method such as GetKeyboardLayout
		var returnState = ToUnicodeEx(key, scanCode, keyboardState, result, 10, 0,  language);
		return new Tuple<string, int>(result.ToString(),returnState);
	}
	[DllImport("user32.dll")]
	internal static extern int ToUnicodeEx(Keys wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetKeyboardLayout(int dwLayout);
