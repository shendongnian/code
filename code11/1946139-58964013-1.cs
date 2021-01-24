 c#
public struct TV : IEquatable<TV>
{
    public override string ToString() => nameof(TV);
    public int B;
    public int BC;
    public int P;
    public int PO;
    public int PC;
    public int W;
    public int WO;
    public int WC;
    public int R;
    public int RO;
    public int RC;
    public int G;
    public int GO;
    public int GC;
    public int GW;
    public int GWO;
    public int GWC;
    public TV(int b, int bC, int p, int po, int pC, int w, int wo, int wC, int r, int ro, int rC, int g, int go, int gC, int gw, int gwo, int gwC)
    {
        B = b;
        BC = bC;
        P = p;
        PO = po;
        PC = pC;
        W = w;
        WO = wo;
        WC = wC;
        R = r;
        RO = ro;
        RC = rC;
        G = g;
        GO = go;
        GC = gC;
        GW = gw;
        GWO = gwo;
        GWC = gwC;
    }
    public override bool Equals(object obj) => obj is TV other && Equals(other);
    public bool Equals(TV other)
    {
        return B == other.B &&
               BC == other.BC &&
               P == other.P &&
               PO == other.PO &&
               PC == other.PC &&
               W == other.W &&
               WO == other.WO &&
               WC == other.WC &&
               R == other.R &&
               RO == other.RO &&
               RC == other.RC &&
               G == other.G &&
               GO == other.GO &&
               GC == other.GC &&
               GW == other.GW &&
               GWO == other.GWO &&
               GWC == other.GWC;
    }
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(B);
        hash.Add(BC);
        hash.Add(P);
        hash.Add(PO);
        hash.Add(PC);
        hash.Add(W);
        hash.Add(WO);
        hash.Add(WC);
        hash.Add(R);
        hash.Add(RO);
        hash.Add(RC);
        hash.Add(G);
        hash.Add(GO);
        hash.Add(GC);
        hash.Add(GW);
        hash.Add(GWO);
        hash.Add(GWC);
        return hash.ToHashCode();
    }
}
