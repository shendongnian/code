     public class Dipendente 
     {
         ...
         public override string ToString() 
         {  
             // Put here all the fields / properties you mant to see in the derired format
             return string.Join("; ",
               $"Id = {Id}",
               $"Nome = {Nome}", 
               $"Cognome = {Cognome}"  
             );
         }
     }
