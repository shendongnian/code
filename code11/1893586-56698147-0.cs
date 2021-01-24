    //something along these lines:
    using UnityEngine;
    using System.Collections.Generic;
    public class CardDeckManager : Monobehaviour, IPointerClickHandler
    {
        [serializeField]
        private List<GameObject> _cards; // If I were you I'd have a Monobehaviour class "Card" or so, which each card has, then you can replace BoxCollider2D with that and access functionality for cards in the deck from here
        public void OnPointerClick(PointerClickEventData data)
        {
            var topmostCard = _cards[0];
            _cards.RemoveAt(0); // remove the topmost card from the deck
            DoSomethingWith(topmostCard); // and have it played
            // For example move it to the center of the table... and have it affect the game logic
        }
        // assign _cards these in editor, or generate them programmatically
    }
