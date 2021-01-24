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
