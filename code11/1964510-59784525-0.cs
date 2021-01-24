foreach (Payment payment in payments)
    {
        payment.PersonDetails = persons.Where(p =>  payment.PaymentPersonIds.Contains(p.ToString()));
    }
Here is the full code: 
public class Person
{
    public int Id { get; set; }
    public string FnName { get; set; }
    public string LnName { get; set; }
}
public class Payment
{
    public int PaymentId { get; set; }
    public string PaymentType { get; set; }
    public IEnumerable<string> PaymentPersonIds { get; set; }
    public IEnumerable<Person> PersonDetails { get; set; }
    /// <summary> FIll PersonDetails property using Linq </summary>
    /// <param name="payments">List of payments</param>
    /// <param name="persons">List of persons</param>
    public static void FillPersonDetailsLinq(List<Payment> payments, List<Person> persons)
    {            
        foreach (Payment payment in payments)
        {
           payment.PersonDetails = persons.Where(p => payment.PaymentPersonIds.Contains(p.Id.ToString()));
        }           
    }
    /// <summary> FIll PersonDetails property without using Linq </summary>
    /// <param name="payments">List of payments</param>
    /// <param name="persons">List of persons</param>
    public static void FillPersonDetails(List<Payment> payments, List<Person> persons)
    {
        foreach (Payment payment in payments)
        {
            List<Person> matches = new List<Person>();
            foreach (Person person in persons)
            {
                if (payment.PaymentPersonIds.Contains(person.Id.ToString()))
                {
                    matches.Add(person);
                }
            }
            payment.PersonDetails = matches;
        }
    }
}
