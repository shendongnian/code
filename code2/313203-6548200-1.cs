    // Define a student variable.
    Student s;
    // And object of type Student1.
    Student1 s1 = new Student1(10, 5, 8);
    // Perform placement of the object to variable.
    s = s1;
    // And run the function of Student1.
    // But it makes no sense...
    s1.Sum();
    // Maybe the exercise wants it:
    ((Student1)s).Sum();
    // Which makes no sense too, since is making an idiot cast.
    // But for learning purposes, ok.
