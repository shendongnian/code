            for (int x = 0; x <= cantidad - 1; x++)
            {
           
                string json1 = Videos.videos.results[x].ToString();
                Results informacion = JsonConvert.DeserializeObject<Results>(json1);
                richTextBox1.Text += "     "+informacion.Key; //Confirm Its Ok!
            }
}
