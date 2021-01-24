cs
public static IEnumerable<Marque> lesMarques()
{
	yield return new Marque("Beta");
	yield return new Marque("Gas Gas");
	yield return new Marque("Honda");
	yield return new Marque("Husaberg");
	yield return new Marque("Husqvarna");
	yield return new Marque("Kawasaki");
	yield return new Marque("KTM");
	yield return new Marque("Sherco");
	yield return new Marque("Suzuki");
	yield return new Marque("TM");
	yield return new Marque("Yamaha");
}
and iterate over them. You don't need to create a new `List` again, when add items to combobox
cs
foreach (Marque uneMarque in Marque.lesMarques())
{
    this.lesMarques.Items.Add(uneMarque);
}
Your current code
cs
public List<Marque> lesMarques()
        {
            List<Marque> lesMarques = new List<Marque>();
            lesMarques.Add(new Marque("Beta"));
            lesMarques.Add(new Marque("Gas Gas"));
            lesMarques.Add(new Marque("Honda"));
            lesMarques.Add(new Marque("Husaberg"));
            lesMarques.Add(new Marque("Husqvarna"));
            lesMarques.Add(new Marque("Kawasaki"));
            lesMarques.Add(new Marque("KTM"));
            lesMarques.Add(new Marque("Sherco"));
            lesMarques.Add(new Marque("Suzuki"));
            lesMarques.Add(new Marque("TM"));
            lesMarques.Add(new Marque("Yamaha"));
            foreach(Marque uneMarque in lesMarques)
            {
                lesMarques.Add(uneMarque);
            }
            return lesMarques;
        }
adds items to `lesMarques` list twice, one by one and then in `foreach` loop again
