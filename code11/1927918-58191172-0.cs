    List<int> scores = new List<int>();
    using (StreamReader sr = File.OpenText("Exam_scores.txt"))
    {
        string s = "";
        while ((s = sr.ReadLine()) != null)
        {
            int score = int.Parse(s);
            scores.Add(score);
        }
    }
