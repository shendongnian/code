    int size = Oo.Length();
    for(int i = 0; i < size; i++){
        if (Oo[i].AddSeconds(30) < DateTime.Now){
            Oo[i].RemoveAt(i);
            size--; // Compensate for new size after removal.
        }
    }
