    // Get Rectangle for second column in second row.
    var cellRectangle = dataGridView1.GetCellDisplayRectangle(1, 1, true);
    // Can create Points using the Rectangle if you want.
    Console.WriteLine("Top Left     x:{0}\t y:{1}", cellRectangle.Left, cellRectangle.Top);
    Console.WriteLine("Bottom Right x:{0}\t y:{1}", cellRectangle.Right, cellRectangle.Bottom);
