lang-cs
public static Guid AddProfesseur(string prenom, string nom)
{
        using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
        {
            ObjectParameter objParam = new ObjectParameter("identity", typeof(Guid));
            var resultToReturn = db.AjouterProfesseur(prenom, nom, objParam).Count();
            return  Guid.Parse(objParam.Value.ToString());
        }
}
You could also use `.ToList()`, `.FirstOrDefault()`, or whatever method you prefer to read the underlying result.
