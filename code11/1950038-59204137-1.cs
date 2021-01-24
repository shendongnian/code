public static class RectTransformExtension
    {
        /// <summary>Sometimes sizeDelta works, sometimes rect works, sometimes neither work and you need to get the layout properties.
        ///	This method provides a simple way to get the size of a RectTransform, no matter what's driving it or what the anchor values are.
        /// </summary>
        /// <param name="rectTransform">The rect transform to check.</param>
        /// <returns>The proper size of the RectTransform.</returns>
        public static Vector2 GetProperSize(this RectTransform rectTransform) //, bool attemptToRefreshLayout = false)
        {
            Vector2 size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
            if (size.x == 0 && size.y == 0)
            {
                size.x = LayoutUtility.GetPreferredWidth(rectTransform);
                size.y = LayoutUtility.GetPreferredHeight(rectTransform);
            }
            if (size.x == 0 && size.y == 0)
            {
                LayoutGroup layoutGroup = rectTransform.GetComponent<LayoutGroup>();
                if (layoutGroup != null)
                {
                    size.x = layoutGroup.preferredWidth;
                    size.y = layoutGroup.preferredHeight;
                }
            }
            return size;
        }
    }
