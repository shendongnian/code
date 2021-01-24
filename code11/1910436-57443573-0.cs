public override string prodName { set => /*do something specific for ProteinPowder*/}
public override int amount()
{
    // do something specific for ProteinPowder
}
Your second thing you raise regarding `public proPowder(string name, int amount) // Is this correct?` and the answer is no.
I am assuming this is meant to be the constructor due to the lack of return type. The constructor must match the name of the class so this should read
public ProteinPowder(string name, int amount)
