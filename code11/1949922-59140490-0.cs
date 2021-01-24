       using System.IO;
       using System.Linq;
       ...
       private void Button4_Click(object sender, EventArgs e) {
         var numbers = File
           .ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "file.txt"))
           .Skip(7)
           .SelectMany(line => line.Split(' ')); 
         richTextBox4.Text = string.Join(" ", numbers);
       }
