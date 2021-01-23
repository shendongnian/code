    for(int i = 0; i< My_Matrix_Image.Height; i++)
    {
        //LOOP 1 SET THE FRONT ROWS
        for (int j = 0; j<40; j++)
        {
            My_Matrix_Image.Data[i,j,0] = 0; //RED
            My_Matrix_Image.Data[i,j,1] = 0; //GREEN
            My_Matrix_Image.Data[i,j,2] = 0; //BLUE
        }
        // LOOP 2 SET THE BACK ROWS
        for (int j = 60; j < My_Matrix_Image.Width; j++)
        {
            My_Matrix_Image.Data[i,j,0] = 0; //RED
            My_Matrix_Image.Data[i,j,1] = 0; //GREEN
            My_Matrix_Image.Data[i,j,2] = 0; //BLUE
        }
    }
