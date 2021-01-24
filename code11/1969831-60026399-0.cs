await foreach (SimpleB B in (from b in db.Blogs where something == "somthing").ToListAsync()))
{
     var DtoObject = new DtoObject();
     DtoObject.Id = A.Id;
     DtoObject.SimpleA = A.Name;
     DtoObject.SimpleB = B.Name;
     simpleDtoList.Add(DtoObject);
}
