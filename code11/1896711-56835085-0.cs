    public enum General : int
    {
        One = 0,
        Two = 1,
        Three = 2,
        Four = 4,
        Five = 8
    }
    public enum A : int
    {
        One = General.One,
        Two = General.Two,
        Three = General.Three,
        Four = General.Four,
    }
    public enum B : int
    {
        Three = General.Three,
        Four = General.Four,
        Five = General.Five
    }
    public enum C : int
    {
        One = General.One,
        Three = General.Three,
        Five = General.Five
    }
    public class Test
    {
        public void testConvert()
        {
            A valAsA = A.One | A.Three | A.Four;
            B valAsB = convertFct(valAsA); // Should give me "B.Three | B.Four"
            C valAsC = convertFct(valAsA); // Should give me "C.One | C.Three"
        }
    }
