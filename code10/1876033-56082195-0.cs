    if (move)
            {
             //boolean is created to return if paint is in the array
                bool blnUnique = true;
                foreach (GameObject temp in array)
                {
                    if (temp == paint)
                    {
                        blnUnique = false;
                    }
                }
                if (blnUnique)
                {
                    vector3 positions = transform.position + new Vector3(0f, -0.5f, 0f); //when player move then paint instantiate y position 
                    array[temp] = Instantiate<GameObject>(paint, position, Quaternion.identity);
                    temp++;
                    newtargetposition = position;
                    Debug.Log("newtargetposiiton:" + newtargetposition);
                    if (temp == 150)
                    {
                        if (newtargetposition == position)
                        {
                            //what can i do here
                            //i dont want to paint here because position store in newtargetposition,it is repeat
                            //array[temp]--;
                            Debug.Log("newtargetpositions:" + newtargetposition);
                            //temp--;
                        }
                        gameOver.SetActive(true);
                        SceneManager.LoadScene(1);
                    }
                }
            }
