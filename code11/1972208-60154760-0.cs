using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dice : MonoBehaviour {
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private List<int> results;
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }
    private void UseResult(int result)
    {
        results.Add(result);
    }
    private void FinishResults()
    {
        foreach (int i : results)
        {
            Debug.Log(i);
        }
    }
    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;
        int finalSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);
            rend.sprite = diceSides[randomDiceSide];
            UseResult(randomDiceSide);
            yield return new WaitForSeconds(0.05f);
        }
        FinishResults();
        finalSide = randomDiceSide + 1;
        Debug.Log(finalSide);
    }
}
Note: Typed on phone, please excuse any syntax errors or other minor mistakes.
