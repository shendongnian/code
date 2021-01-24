    int length = 100;
    string word = "is";
    string sentence = "Football is a great game It is most popular game all over the world It is not only a game but also a festival of get together for the nations which is most exciting too";
    //Substring with desired length
    sentence = sentence.Substring(0, length);
    int count = 0;
    //creating an array of words
    string[] words = sentence.Split(Convert.ToChar(" "));
    //linq query
    count = words.Where(x => x == word).Count();
    Debug.WriteLine(count);
