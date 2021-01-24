csharp
...
using (Stream inputStream = eqc) {
MemoryStream memoryStream = inputStream as MemoryStream; //eqc is a FileStream, it is not castable as MemoryStream, This is always null
...
**Solution**
Here is a *small refactor* of your function. I removed `unused variables` and I've moved variable definition closer to the usage. You will also notice that there is no `if ()` statement remaining (`Directory.CreateDirectory()` will not throw an exception if directory already exist). <br>
**My rule for better code** : Remove as many [if] as possible, it will reduce code paths and chances of errors.
csharp
public ActionResult EditPersonalityTest([Bind(Include = "ID,EnglishProefficiencyBefore")] Recipient recipient, CohortSubscriptions cohortSubscriptions)
{
    var property = db.CohortSubscriptions.Where(x => x.ID == cohortSubscriptions.ID).FirstOrDefault();
    property.EnglishProefficiencyBefore = cohortSubscriptions.EnglishProefficiencyBefore;
    db.Entry(property).State = EntityState.Modified;
    db.SaveChanges();
    Registrations registration = db.Registrations.Where(x => x.ID == property.RegistrationId).FirstOrDefault();
    recipient.Name = registration.FirstName + " " + registration.LastName;
    recipient.Email = registration.Email;
    //Array to map campus name to FileNamePart
    var campusNameMap = new[] {
        new { PreferredCampus = "Montreal", FileNamePart = "Montreal" },
        new { PreferredCampus = "Québec", FileNamePart = "Quebec" },
    };
    //Generate pdfDocumentPath based on isEnglish and registration.PreferredCampus
    string campusFileNamePart = campusNameMap.Single(campus => campus.PreferredCampus == registration.PreferredCampus).FileNamePart;
    string languageFileNamePart = IsEnglishLocale(registration) ? "English" : "French";
    //Use only 1 inputStream
    using (FileStream inputStream = new FileStream(Server.MapPath($"~/Documents/Contrats {campusFileNamePart} {languageFileNamePart}.pdf"), FileMode.Open))
    {
        MemoryStream memoryStream = new MemoryStream();
        inputStream.CopyTo(memoryStream);
        string directorypath = Server.MapPath("~/App_Data/Files/");
        Directory.CreateDirectory(directorypath);
        string serverpath = $"{directorypath}{recipient.Name.Trim()}.pdf";
        System.IO.File.WriteAllBytes(serverpath, memoryStream.ToArray());
        docusignContract(serverpath, recipient.Name, recipient.Email);
        System.IO.File.Delete(serverpath);
    }
    return View("ConfirmEditSubscriptions");
}
I hope it will work for you.
