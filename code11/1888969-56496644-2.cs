internal interface IDataAdapter<TForm> where TForm : IApplicationForm
{
    StringContent FormatOutput(TForm form);
}
internal class MortgageApplicationFormAdapter : IDataAdapter<MortgageApplicationForm>
{
    public StringContent FormatOutput(MortgageApplicationForm form)
    {
        return new StringContent("", Encoding.UTF8, MediaType.Json.Description());
    }
}
That you want to specify `MortgageApplicationForm` as the form type indicates that every implementation of the interface would also be for a specific form type. 
If you wanted one implementation that worked with any form type then the generic argument would be on the method. If you want every implementation to handle a specific form type then the generic argument would on the interface itself.
