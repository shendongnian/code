                //Attemps string conversion for each of the point's variables
                int.TryParse(row[0], out q.pointID); //Checks for existence of data on the line...
                float.TryParse(row[1], out q.xValue); //Input x-value
                float.TryParse(row[2], out q.yValue); //Input y-value
                float.TryParse(row[3], out q.zValue); //Input z-value
                float.TryParse(row[4], out q.tempValue); //Input temp-value (For use in Heatmaps)
            }
            catch (IndexOutOfRangeException iore)
            {
                Debug.Log("File out of range...");
                errorLogScript.errorCode = 1100;
                SceneManager.LoadScene(4);
            }`
