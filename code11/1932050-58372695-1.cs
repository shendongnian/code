     public class Dipendente 
     {
         ...
         public override string ToString() 
         {  
             // Put here all the fields / properties you mant to see in the derired format
             // Here we have "Id = 123; Nome = John; Cognome = Smith" format
             return string.Join("; ",
               $"Id = {Id}",
               $"Nome = {Nome}", 
               $"Cognome = {Cognome}"  
             );
         }
     }
