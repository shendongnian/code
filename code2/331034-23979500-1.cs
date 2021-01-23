    class Game
        {
            //property on Game to save all elements
            Element[] Elements { get; set; }
            public Game(Element[] elements)
            {
                Elements = elements;
            }
    
            public void PrintGameElements()
            {
                foreach (var element in Elements)
                {
                    Console.WriteLine(element.ElementData);
                }
            }
    
            public void PrintElement(int index)
            {
                Console.WriteLine(Elements[index].ElementData);
            }
        }
