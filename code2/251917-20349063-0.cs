    using System;
    
    class pyramid {
    
          static void Main() {
    	       
    		   /** Pyramid stars Looking down 
    		       Comment this if u need only a upside pyramid **/
    		   
    	       int row, i, j;
    		   
    		   // Total number of rows
    		   // You can get this as users input 
    		   //row =  Int32.Parse(Console.ReadLine());
               row = 5;      		
    			
    		   // To print odd number count stars use a temp variable
    		   int temp;
    		   temp = row;
               
    		   // Number of rows to print 
    		   // The number of row here is 'row'
    		   // You can change this as users input 
    		   for ( j = 1 ; j <= row ; j++ ) {	
               
    		   // Printing odd numbers of stars to get 
               // Number of stars that you want to print with respect to the value of "i"?		   
    		       for ( i = 1 ; i <= 2*temp - 1 ; i++ )
    				   Console.Write("*");
    				   
    		   // New line after printing a row 		   
    			   Console.Write("\n");
    		       for ( i = 1 ; i <= j ; i++ )			       
    				   Console.Write(" ");
    				   
               // Reduce temp value to reduce stars count  				   
    		  	   temp--;
    		   }
    		   
    		   /** Pyramid stars Looking up 
    		       Comment this if u need only a downside pyramid **/
    		   int rowx, k, l;
    		   
    		   // Total number of rows
    		   // You can get this as users input 
    		   // rowx =  Int32.Parse(Console.ReadLine());
               rowx = 5; 
    		   
    		   // To print odd number count stars use a temp variable
    		   int tempx;
               tempx = rowx;
    		   
    		   //Remove this if u use 
    		   Console.Write("\n");
    		   
    		   // Number of rows to print 
    		   // The number of row here is 'rowx'
    		  
               for ( l = 1 ; l <= rowx ; l++ ) {
    		   
    		   // Leaving spaces with respect to row
                   for ( k = 1 ; k < tempx ; k++ )
                       Console.Write(" ");
    				   
               // Reduce tempx value to reduce space(" ") count  
                   tempx--;
    			   
               // Printing stars 
                   for ( k = 1 ; k <= 2*l - 1 ; k++ )
                       Console.Write("*"); 
    				   
    		   // New line after printing a row 
                   Console.Write("\n");
               }		   
    	  }
    }
