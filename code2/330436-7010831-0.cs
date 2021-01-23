        enum animals
        {
            cat,
            dog,
            fish
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string myAnimal in Enum.GetNames(typeof(animals)))
            {
                Debug.WriteLine(myAnimal);
            }
        }
