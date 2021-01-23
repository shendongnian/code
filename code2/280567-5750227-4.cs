	imports Microsoft.VisualBasic
	imports System
	
	public module MyModule
		Sub Main()
			Console.OutputEncoding = System.Text.Encoding.UTF8
			dim i as integer
			for i = 0 to 1000
				Console.Write(ChrW(i))
				if i mod 50 = 0 'break every 50 chars 
					Console.WriteLine()
				end if
			next
		Console.ReadKey()
		End Sub
	end module
