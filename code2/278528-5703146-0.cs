    [HttpPost]
    public ActionResult Edit(TableA formdata)
    {
        TableA temp = myDB.TableA.First(a=>a.Id == formdata.Id);
    
        temp.TableB = myDB.TableB.First(a => a.Id == formdata.TableB.Id); // Refactored!!!!
    
        temp.field1= formdata.field1;
        temp.field2= formdata.field2;
        temp.field3= formdata.field3;
    
        myDB.SaveChanges();
        return RedirectToAction("Index");
    }
