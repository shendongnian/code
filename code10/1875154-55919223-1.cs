    public void moveObject() {
       MouseCoordinates coordinates = GetMouseCoordinates(); //There are a lot of ways.
       chair.locationY = coordinates.Y + chair.sizeY / 2;
       chair.locationX = coordinates.X + chair.sizeX / 2;
    }
