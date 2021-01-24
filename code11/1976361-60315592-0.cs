    using System;
    using System.Text;
					
    public class Program {
    	public static void Main() {
            string text_txt = "Ð¿ÑÐ¸Ð²ÐµÑ";
            byte[] bytesUtf8 = Encoding.UTF8.GetBytes(text_txt);
            text_txt = Encoding.UTF8.GetString(bytesUtf8);
		
            Console.WriteLine(text_txt);
    	}
    }
