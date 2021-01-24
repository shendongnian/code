    //Looping through the array based on count. 
          for (int i = 0; i < values.Length; i++) {
           //This will only append rows 7-9. Keep in mind an array is a 0 based
           //index. Meaning row 7 is actually array element 6. Row 9 is actually
           //array element 8. 
           if(i > 5 && i < 9){
               richTextBox4.AppendText(values[i] + " ");
           }
          }
         }
        }
