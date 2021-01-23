    List<string> dinosaurs = new List<string>();
    dinosaurs.Add("Triceratops");
    dinosaurs.Add("Stegosaurus");
    Console.WriteLine("Count: {0}", dinosaurs.Count);
    dinosaurs.Clear();
    dinosaurs.TrimExcess();
    Console.WriteLine("\nClear() and TrimExcess()");
    Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);
    Console.WriteLine("Count: {0}", dinosaurs.Count);
