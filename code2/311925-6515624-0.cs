    class Sample1
    {
        #region Private member variables ('costOf' and 'Input' data)
        float _Alligor;
        float _Briochit;
        float _Chollonin;
        // ... etc, etc.
        #endregion
        #region Public Properties for costOf and Input data
        public float Alligor { get { return _Alligor; } set { _Alligor = value; } }
        // ... etc. etc.
        #endregion
        public void Calculate()
        {
            costofAlligor = Alligor * AlligorInput;
            costofBriochit = Briochit * BriochitInput;
            costofChollonin = Chollonin * CholloninInput;
            costofEspitium = Espitium * EspitiumInput;
            costofHydrobenol = Hydrobenol * HydrobenolInput;
            costofIsopropenetol = Isopropenetol * IsopropenetolInput;
            costofMetachropin = Metachropin * MetachropinInput;
            costofPhlobotil = Phlobotil * PhlobotilInput;
            costofPlasteosine = Plasteosine * PlasteosineInput;
            costofPolynitrocol = Polynitrocol * PolynitrocolInput;
            costofPolynucleit = Polynucleit * PolynucleitInput;
            costofPrilumium = Prilumium * PrilumiumInput;
            costofStatchanol = Statchanol * StatchanolInput;
            costofTitanium = Titanium * TitaniumInput;
            costofVitricyl = Vitricyl * VitricylInput;
            totalCost = costofAlligor + costofBriochit + costofChollonin + costofEspitium + costofHydrobenol + costofIsopropenetol + costofMetachropin + costofPhlobotil + costofPlasteosine + costofPolynitrocol + costofPolynucleit + costofPrilumium + costofStatchanol + costofTitanium + costofVitricyl;
        }
        double totalCost;
        public double TotalCost { get { return totalCost;  } }
    }
