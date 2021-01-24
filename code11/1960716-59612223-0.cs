    string RolledNumberCode = Program.form1.DicePort.ReadExisting();
    if (RolledNumberCode.Contains("e"))
    {
        int RolledNumber = Convert.ToInt32(RolledNumberCode.Replace("e",""));
        dice.RollAnalog(RolledNumber);
    }
