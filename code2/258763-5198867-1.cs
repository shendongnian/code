     string text = "My quasi secret text.";
    
     byte[] buffer = System.Text.UTF8Encoding.ASCII.GetBytes(text);
    
     string protectedText = Convert.ToBase64String(buffer);
 
     File.WriteAllText(filename, protectedText)
