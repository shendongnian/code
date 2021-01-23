    Console.Write("Enter an ISBN: ");
    var isbn = Console.ReadLine();
    using (var frm = new IsbnForm())
    {
        frm.Isbn = isbn;  // populates the field in the form.
        var rslt = frm.ShowDialog();
        // etc, etc.
    }
