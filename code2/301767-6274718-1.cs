    XmlDocument doc     = new XmlDocument();
    
    try
    {
        using (var reader = XmlReader.Create("Presentation.xml"))
        {
            int numSlides;
    
            doc.Load(reader);
    
            XmlElement root = doc.DocumentElement;
    
            //get number of slides from threshold node
            numSlides = Convert.ToInt32(root.SelectSingleNode("//threshold").InnerText);
    
            //get number of quizzes/slides
            XmlNodeList xnQuiz = root.SelectNodes("/Presentation/Slides/Slide/quizobjects"); //returns 7
            XmlNodeList xnList = root.SelectNodes("/Presentation/Slides/Slide");
    
            //create array to hold location of quizzes
            int[] quizLocArray = new int[xnQuiz.Count];
    
            int j = 0;
    
            //find index of quizzes in slide list
            for (int i = 0; i < xnList.Count; i++)
            {
                XmlNode quiz = xnList[i].SelectSingleNode("quizobjects");
                if (quiz != null)
                {
                    quizLocArray[j] = (i + 1);
                    j++;
                }
            }
        }
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
