C#
List<Projet> projets = await projetService.NewProjetLine(GestionaireId, VilleId);
foreach (var p in projects)
{
  int villeId = await villeService.getVilleIdByProjetId(p.ProjetId);
  Ville ville = await villeService.GetById(villeId);
  p.Ville = ville.VilleLabel;
  p.GestionnaireProjet = await userServices.GetNameById(p.GestionnaireProjetId ?? 0);
  foreach (var sp in p.SousProject)
  {
    sp.Avancement = await avancementService.GetLabelById(sp.AvancementId);
  }
}
model.projets = projets;
Or, if you want to use asynchronous concurrency, you can make use of `Task.WhenAll`:
C#
List<Projet> projets = await projetService.NewProjetLine(GestionaireId, VilleId);
await Task.WhenAll(projects.Select(async p =>
{
  int villeId = await villeService.getVilleIdByProjetId(p.ProjetId);
  Ville ville = await villeService.GetById(villeId);
  p.Ville = ville.VilleLabel;
  p.GestionnaireProjet = await userServices.GetNameById(p.GestionnaireProjetId ?? 0);
  await Task.WhenAll(p.SousProject.Select(async sp =>
  {
    sp.Avancement = await avancementService.GetLabelById(sp.AvancementId);
  });
});
model.projets = projets;
  [1]: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx
