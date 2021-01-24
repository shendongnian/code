using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameOverManager : MonoBehaviour
{
    public GameObject _player;
    public GameObject _endscreen;
    void Update()
    {
        if (_player.activeInHierarchy == false)
        {
            _endscreen.SetActive(true);
        }
        else
        {
            _endscreen.SetActive(false);
        }
    }
}
Assign the Variables in the Inspector by dragging the object to the empty fields. Never use GameObject.Find Methods.
If you need any further help tell me :)
