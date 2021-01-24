     .Project<DataBaseObject, ProjectObject>(model => new DataBaseOject
                  {
                      externalId = model.Id,
                      PV = new List<ProjectObject>()
                  })
