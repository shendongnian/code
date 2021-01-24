    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Growth : MonoBehaviour
    {
        SetupScene setup; //mi serve per prendere il prefab
        TimeManager timeManager;
        float currentLenght;
        float currentWidth;
        Genetic geneticInfo;
        bool isMaxLenght;  //internodo ha raggiunto la lunghezza massima
        bool isMaxWeigth;
        GameObject newInternode;
        float annualLengthGrowth = Runge.runge(0.0f, 1.0f, 1.0f, .1f, new Runge.Function(Equation.equation)); //0.05f; // per ora lo fissiamo da codice, successivamente verra' calcolato
        float annualWidthGrowth = 0.01f;
        Vector3 annualGrowth;
        bool hasChild;
        
    
        // Start is called before the first frame update
        void Awake()
        {
            annualGrowth = new Vector3(annualWidthGrowth, annualLengthGrowth, annualWidthGrowth);
            setup = GameObject.Find("Setup").GetComponent<SetupScene>();
            timeManager = GameObject.Find("Time Manager").GetComponent<TimeManager>();
            currentLenght = 0f;
            currentWidth = 0f;
            geneticInfo = new Genetic(1);
        }
    
        // Update is called once per frame
        void Update()
        {
            Debug.Log("ciao, sono nato " + gameObject.name);
            Debug.Log(timeManager.IsYearElapsed + " " + gameObject.name);
            if (timeManager.IsYearElapsed)
            {
                
                //calcolo lunghezza e larghezza corrente
                float scaleFactorXZ = 1f;
                float scaleFactorY = 1f;
                if (gameObject.name != "Seed")
                {
                    scaleFactorXZ = geneticInfo.InternodeMaxWidtht;
                    scaleFactorY = geneticInfo.InternodeMaxLenght;
                }
                currentLenght = (gameObject.transform.lossyScale.y + annualGrowth.y);
                Debug.Log("Lunghezza corrente internodo = " + currentLenght);
                currentWidth = (gameObject.transform.lossyScale.x + annualGrowth.x);
    
               
    
                if(currentWidth > geneticInfo.InternodeMaxWidtht)
                {
                    currentWidth = geneticInfo.InternodeMaxWidtht;
                    isMaxWeigth = true;
                }
    
                if(currentLenght > geneticInfo.InternodeMaxLenght)
                {
                    currentLenght = geneticInfo.InternodeMaxLenght;
                    isMaxLenght = true;
                }
    
                
                
                gameObject.transform.localScale = new Vector3(currentWidth/scaleFactorXZ, currentLenght/scaleFactorY, currentWidth/scaleFactorXZ);
               
                
    
                if (isMaxLenght)
                {
                    //crea nuovo internodo come figlio di quello corrente
                    if (!hasChild && setup.Manager.InternodeNumber < geneticInfo.MaxInternodeNumber)
                    {
                        setup.Manager.InternodeNumber++;
                        Debug.Log("nuovo internodo creato");
                        setup.LastInternodePosition = gameObject.transform.position + new Vector3(0f, geneticInfo.InternodeMaxLenght, 0f);
                        newInternode = Instantiate(setup.Prefab, new Vector3(setup.LastInternodePosition.x, setup.LastInternodePosition.y, setup.LastInternodePosition.z), Quaternion.identity);
                        newInternode.transform.localScale = Vector3.zero;
                        newInternode.transform.parent = setup.LastInternode.transform;
                        setup.LastInternode = newInternode;
                        //creare nuova classe gestore Gerarchia
                        newInternode.AddComponent<Growth>();
                        hasChild = true;
                    }
                    
                    if (isMaxWeigth)
                    {
                        gameObject.GetComponent<Growth>().enabled = false;
                    }
    
                }
            }
        }
    
        public class Runge
        {
            //declare a delegate that takes a double and returns
            public delegate float Function(float t, float annualGrowth);
    
            public static float runge(float a, float b, float value, float step, Function f)
            {
                float t, w, k1, k2, k3, k4;
                t = a;
                w = value;
                for (int i = 0; i < (b - a) / step; i++)
                {
                    k1 = step * f(t, w);
                    k2 = step * f(t + step / 2f, w + k1 / 2f);
                    k3 = step * f(t + step / 2f, w + k2 / 2f);
                    k4 = step * f(t + step, w + k3);
                    w = w + (k1 + 2f * k2 + 2f * k3 + k4) / 6f;
                    t = a + i * step;
                    //Console.WriteLine("{0} {1} ", Math.Round(t, 1), w);
                }
    
            }
        }
    
        class Equation
        {
            public static float equation(float t, float annualGrowth)
            {
                float y_prime;
                float k = 0.1f; //fattore di crescita, deve essere non hardcodato
                float maxHeight = 5.0f; //altezza max, deve essere non hardcodato
                return y_prime = k * annualGrowth * (1 - (annualGrowth / maxHeight));
            }
    
        }
    }
