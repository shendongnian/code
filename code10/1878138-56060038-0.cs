    public string Recognise(Image<Gray, byte> Input_image, int Eigen_Thresh = -1)
        {
            if (_IsTrained)
            {
                FaceRecognizer.PredictionResult ER = recognizer.Predict(Input_image);
                if (ER.Label == -1)
                {
                    Eigen_label = "Unknown";
                    Eigen_Distance = 0;
                    return Eigen_label;
                }
                else
                {
                    Eigen_label = Names_List[ER.Label];
                    Eigen_Distance = (float)ER.Distance;
                    if (Eigen_Thresh > -1) Eigen_threshold = Eigen_Thresh;
                    Console.WriteLine("-Recognise Distance-" + Eigen_Distance + "--" + "Possible Label- " + "--" + Eigen_label);
                    //Only use the post threshold rule if we are using an Eigen Recognizer 
                    //since Fisher and LBHP threshold set during the constructor will work correctly 
                    switch (Recognizer_Type)
                    {
                        case ("EMGU.CV.EigenFaceRecognizer"):
                            Console.WriteLine("I'm in");
                            if (Eigen_Distance >= Eigen_threshold)
                            {
                                return Eigen_label; //işareti değiştiridim.z
                            }
                            else return "";
                        case ("EMGU.CV.LBPHFaceRecognizer"):
                            if (Eigen_Distance < 100)
                            {
                                return Eigen_label;
                            }
                            else return "Noise";
                        case ("EMGU.CV.FisherFaceRecognizer"):
                        default:
                            return Eigen_label; //the threshold set in training controls unknowns
                    }
                }
            }
            else return "";
        }
