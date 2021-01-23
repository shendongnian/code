    var item = pricePublicList.FirstOrDefault(x => x.Size == 200);
    if (item != null) {
       // There exists one with size 200 and is stored in item now
    }
    else {
      // There is no PricePublicModel with size 200
    }
