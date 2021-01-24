    using System.Runtime.CompilerServices;
    /// ...
	
    bool _bool;
	byte _byte;
	_bool = true;
	_byte = Unsafe.As<bool, byte>(ref _bool);
	Console.WriteLine(_byte);           //  -->  1
	_bool = false;
	_byte = Unsafe.As<bool, byte>(ref _bool);
	Console.WriteLine(_byte);           //  -->  0
