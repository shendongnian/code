    [HttpPost]
    public ActionResult Edit(TableA formdata)
    {
        TableA temp = myDB.TableA.First(a=>a.Id == formdata.Id);
        temp.TableB = myDB.TableB.First(a => a.Id == formdata.TableB.Id);
    
        AutoMapper.Mapper.Map(formdata, temp);
        myDB.SaveChanges();
        return RedirectToAction("Index");
    }
