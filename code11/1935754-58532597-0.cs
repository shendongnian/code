BoatSelector.Items.InsertAt(0,boatList[i].GetboatName() + " - " + boatList[i].GetboatLicense());
I think you're adding the items multiple times.
for(int i = 0; i < boatList.Count; i++)
{
    BoatSelector.Items.Add(boatList[i].GetboatName() + " - " + boatList[i].GetboatLicense());
}   
(... at another time)
for(int i = 0; i < boatList.Count; i++)
{
    BoatSelector.Items.Add(boatList[i].GetboatName() + " - " + boatList[i].GetboatLicense());
} 
This means that `BoatSelector.Items` always grows.
You can `Clear()` `Items` or assign a new list:
BoatSelector.Items = boatList
          .Select( item => item.GetboatName() + " - " + item.GetboatLicense())
          .ToList();
