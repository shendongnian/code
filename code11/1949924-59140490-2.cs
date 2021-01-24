       using System.IO;
       using System.Linq;
       ...
       private void Button4_Click(object sender, EventArgs e) {
         var numbers = File
           .ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "file.txt"))
           .Skip(7)
        // .Take(3) // Uncomment it if you want to take at most 3 lines after skip
           .SelectMany(line => line.Split(' ')); 
         richTextBox4.Text = string.Join(" ", numbers);
       }
