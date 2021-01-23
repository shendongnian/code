    using System.IO;
    var combinedList = a1.ToList().AddRange(a2);
    var combinedArray = list.ToArray();
    using (var stream = new StreamWriter(filename))
    {
        stream.Write(combinedArray, 0, combinedArray.Length);
    }
