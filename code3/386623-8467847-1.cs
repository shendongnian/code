    Pets p = new Pets() { Cats = 0, Dogs = 3 };
    Console.WriteLine("{0}, {1}", p.Cats, p.Dogs);
    byte[] serial = Utils.BinarySerialize(p);
    p.Cats = 1;
    Console.WriteLine("{0}, {1}", p.Cats, p.Dogs);
    p = Utils.BinaryDeserialize(serial, p);
    Console.WriteLine("{0}, {1}", p.Cats, p.Dogs);
