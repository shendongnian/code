    public House NextHouse(){
        if(currentIndex + 1 != houseList.Count)
            currentIndex++;
        return houseList[currentIndex]
    }
    
    public House PreviousHouse(){
        if(currentIndex -1 >= 0)
            currentIndex--;
        return houseList[currentIndex];
    }
