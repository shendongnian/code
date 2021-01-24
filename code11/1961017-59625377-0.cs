c#
//modify this to return all of them into mem, and then filter on this... 
//if it can not be done here then do below..
var lstReturnsDetail = dcReturnsService.GetReturnDetailsInfo(header_id);
//then create a list here which fetches all, 
List<[type]> somelist
List<int> listId = lstReturnsDetail.select(x=>x.id).tolist();
using (DCReturns_Entities entities = new DCReturns_Entities())
{
	somelist = entities.HandlingInfoes.Where(f =>  listId.Contains(  f.detail_id)).ToList();
}
foreach (ReturnsDetail oReturnsDetail in lstReturnsDetail)
{
	//performance issue is here
	//using (DCReturns_Entities entities = new DCReturns_Entities())
	//{
	//	lstHandlingInfo = entities.HandlingInfoes.Where(f => f.detail_id == oReturnsDetail.id).ToList();
	//}	
	
	//insead fetach all before, into mem and filter from that list.
	var lstHandlingInfo = somelist.Where(f => f.detail_id == oReturnsDetail.id).ToList();
		
	//code ommited for reaablity
}
//code ommited for reaablity
