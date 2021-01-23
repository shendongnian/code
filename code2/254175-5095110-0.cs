    [Test]
    [ExpectedException (typeof (Y2KBugException))]
    public void TestY2KBug ()
    {
        MDateTime.NowGet = () => new DateTime (2001, 1, 1);
        Bomb.DetonateIfY2K ();
    }
    
    
    public static class Bomb {
        public static void DetonateIfY2K ()
        {
            if (DateTime.Now == new DateTime (2001, 1, 1))
                throw new Y2KBugException (); // take cover!
        }
    }
