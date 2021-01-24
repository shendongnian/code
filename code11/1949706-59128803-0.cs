    //Button Click Event
    private void Button4_Click(object sender, EventArgs e) {
    //Finding your file and assigning it as a string. 
     string start = Directory.GetCurrentDirectory() + @"\Sav1.txt";
    //Using a `using` statement and creating a new streamReader that will look
    //for the string that you created above to find the file. The using block
    //will properly close the streamreader when the work is done. 
     using(var streamReader = new StreamReader(start)) {
    //StreamReader.ReadLine() will read the FIRST line, no loop here.
    //This is why your code only reads one.
      string line = streamReader.ReadLine();
    //Splitting to an array. 
      int[] values = line.Split(' ').Select(int.Parse).ToArray();
    //Sorting array.
      Array.Sort(values);
    //Reversing the array. 
      Array.Reverse(values);
    //Looping through the array based on count. 
      for (int i = 0; i < values.Length; i++) {
       richTextBox4.AppendText(values[i] + " ");
      }
     }
    }
