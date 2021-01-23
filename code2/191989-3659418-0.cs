    public static class IsbnConsole 
    { 
       public static void Main(string[] args) 
        { 
            Console.Write("Enter a valid 10 digit ISBN Number "); 
            string isbn = checkIsbnClass.DestabilizeIsbn(Console.ReadLine()); // Normalizes the input and puts it on string "str" 
            
            Isbn isbn = new Isbn(Console.In)
            if (!isbn.CheckLength())   
                Console.WriteLine("The number you have entered is not a valid ISBN try again."); // Print invalid number 
            } 
            else if (isbn.HasCheckDigit)
            { 
                if (isbn.CheckNumber(isbn)) 
                    Console.WriteLine("The number you have entered is a Valid ISBN"); 
                else
                    Console.WriteLine("The number you have entered is not a valid ISBN try again."); // Print invalid number 
            } 
            else 
            { 
                Console.WriteLine("The Check digit that corresponds to this ISBN number is " + isbn.GetCheckDigit(isbn) + "."); // Print the checksum digit 
            } 
            Console.ReadLine(); 
    }
    
    public class Isbn
    {
       public Isbn(TextReader cin)
       {
            /// do stuff here.
       }
       
       public bool CheckLength()
       {
            /// do stuff here.
       }
    
       public bool HasCheckDigit {  get {    ..... } }
       public int  GetCheckDigit() {..... }
       public bool CheckNumber() {......}
    }
