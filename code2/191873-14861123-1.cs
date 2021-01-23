    using UnityEngine;
    using System.Collections;
    public class teste : MonoBehaviour 
    {
	Randomizator3000.Item<string>[] lista;
	
	void Start()
	{
		lista = new Randomizator3000.Item<string>[10];
		lista[0] = new Randomizator3000.Item<string>();
		lista[0].weight = 10;
		lista[0].value = "a";
		
		lista[1] = new Randomizator3000.Item<string>();
		lista[1].weight = 10;
		lista[1].value = "b";
		
		lista[2] = new Randomizator3000.Item<string>();
		lista[2].weight = 10;
		lista[2].value = "c";
		
		lista[3] = new Randomizator3000.Item<string>();
		lista[3].weight = 10;
		lista[3].value = "d";
		
		lista[4] = new Randomizator3000.Item<string>();
		lista[4].weight = 10;
		lista[4].value = "e";
		
		lista[5] = new Randomizator3000.Item<string>();
		lista[5].weight = 10;
		lista[5].value = "f";
		
		lista[6] = new Randomizator3000.Item<string>();
		lista[6].weight = 10;
		lista[6].value = "g";
		
		lista[7] = new Randomizator3000.Item<string>();
		lista[7].weight = 10;
		lista[7].value = "h";
		
		lista[8] = new Randomizator3000.Item<string>();
		lista[8].weight = 10;
		lista[8].value = "i";
		
		lista[9] = new Randomizator3000.Item<string>();
		lista[9].weight = 10;
		lista[9].value = "j";
	}
	
	void Update () 
	{
		Debug.Log(Randomizator3000.PickOne<string>(lista));
	}
    }
