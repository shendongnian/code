    using Android.Content;
    using Android.Runtime;
    using Android.Widget;
    using Android.Util;
    using Android.Text;
    
    using Java.Lang;
    
    namespace My.Text
    {
        public class AutoResizeTextView : TextView
        {
            public const float MIN_TEXT_SIZE = 20;
    
            public interface OnTextResizeListener
            {
                void OnTextResize(TextView textView, float oldSize, float newSize);
            }
    
            private const string mEllipsis = "...";
    
            private OnTextResizeListener mTextResizeListener;
    
            private bool mNeedsResize = false;
    
            private float mTextSize;
    
            private float mMaxTextSize = 0;
    
            private float mMinTextSize = MIN_TEXT_SIZE;
    
            private float mSpacingMult = 1.0f;
    
            private float mSpacingAdd = 0.0f;
    
            public bool AddEllipsis { get; set; } = true;
    
            public AutoResizeTextView(Context context) : this(context, null) { }
    
            public AutoResizeTextView(Context context, IAttributeSet attrs) : this(context, attrs, 0) { }
    
            public AutoResizeTextView(Context context, IAttributeSet attrs, int defStyle): base(context, attrs, defStyle)
            {
                mTextSize = TextSize;
            }
    
            protected override void OnTextChanged(ICharSequence text, int start, int lengthBefore, int lengthAfter)
            {
                base.OnTextChanged(text, start, lengthBefore, lengthAfter);
    
                mNeedsResize = true;
    
                ResetTextSize();
            }
    
            protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
            {
                base.OnSizeChanged(w, h, oldw, oldh);
    
                if (w != oldw || h != oldh)
                    mNeedsResize = true;
            }
    
            public void SetOnResizeListener(OnTextResizeListener listener)
            {
                mTextResizeListener = listener;
            }
    
            public override void SetTextSize([GeneratedEnum] ComplexUnitType unit, float size)
            {
                base.SetTextSize(unit, size);
    
                mTextSize = TextSize;
            }
    
            public override void SetLineSpacing(float add, float mult)
            {
                base.SetLineSpacing(add, mult);
    
                mSpacingMult = mult;
                mSpacingAdd = add;
            }
    
            public void SetMaxTextSize(float maxTextSize)
            {
                mMaxTextSize = maxTextSize;
                RequestLayout();
                Invalidate();
            }
    
            public float GetMaxTextSize()
            {
                return mMaxTextSize;
            }
    
            public void SetMinTextSize(float minTextSize)
            {
                mMinTextSize = minTextSize;
                RequestLayout();
                Invalidate();
            }
    
            public float GetMinTextSize()
            {
                return mMinTextSize;
            }
    
            public void ResetTextSize()
            {
                if(mTextSize > 0)
                {
                    base.SetTextSize(ComplexUnitType.Px, mTextSize);
                    mMaxTextSize = mTextSize;
                }
            }
    
            protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
            {
                if(changed || mNeedsResize)
                {
                    int widthLimit = (right - left) - CompoundPaddingLeft - CompoundPaddingRight;
                    int heightLimit = (bottom - top) - CompoundPaddingBottom - CompoundPaddingTop;
                    ResizeText(widthLimit, heightLimit);
                }
                base.OnLayout(changed, left, top, right, bottom);
    
                base.OnLayout(changed, left, top, right, bottom);
            }
    
            public void ResizeText()
            {
                int heightLimit = Height - PaddingBottom - PaddingTop;
                int widthLimit = Width - PaddingLeft - PaddingRight;
                ResizeText(widthLimit, heightLimit);
            }
    
            public void ResizeText(int width, int height)
            {
                var text = TextFormatted;
                if (text == null || text.Length() == 0 || height <= 0 || width <= 0 || mTextSize == 0)
                    return;
    
                if (TransformationMethod != null)
                    text = TransformationMethod.GetTransformationFormatted(TextFormatted, this);
    
                TextPaint textPaint = Paint;
    
                float oldTextSize = textPaint.TextSize;
                float targetTextSize = mMaxTextSize > 0 ? System.Math.Min(mTextSize, mMaxTextSize) : mTextSize;
    
                int textHeight = GetTextHeight(text, textPaint, width, targetTextSize);
    
                while(textHeight > height && targetTextSize > mMinTextSize)
                {
                    targetTextSize = System.Math.Max(targetTextSize - 2, mMinTextSize);
                    textHeight = GetTextHeight(text, textPaint, width, targetTextSize);
                }
    
                if(AddEllipsis && targetTextSize == mMinTextSize && textHeight > height)
                {
                    TextPaint paint = new TextPaint(textPaint);
    
                    StaticLayout layout = new StaticLayout(text, paint, width, Layout.Alignment.AlignNormal, mSpacingMult, mSpacingAdd, false);
                    if(layout.LineCount > 0)
                    {
                        int lastLine = layout.GetLineForVertical(height) - 1;
                        if (lastLine < 0)
                            SetText("", BufferType.Normal);
                        else
                        {
                            int start = layout.GetLineStart(lastLine);
                            int end = layout.GetLineEnd(lastLine);
                            float lineWidth = layout.GetLineWidth(lastLine);
                            float ellipseWidth = textPaint.MeasureText(mEllipsis);
    
                            while (width < lineWidth + ellipseWidth)
                                lineWidth = textPaint.MeasureText(text.SubSequence(start, --end + 1).ToString());
                            SetText(text.SubSequence(0, end) + mEllipsis, BufferType.Normal);
                        }
                    }
                }
    
                SetTextSize(ComplexUnitType.Px, targetTextSize);
                SetLineSpacing(mSpacingAdd, mSpacingMult);
    
                mTextResizeListener?.OnTextResize(this, oldTextSize, targetTextSize);
    
                mNeedsResize = false;
            }
    
            private int GetTextHeight(ICharSequence source, TextPaint paint, int width, float textSize)
            {
                TextPaint paintCopy = new TextPaint(paint);
                paintCopy.TextSize = textSize;
                StaticLayout layout = new StaticLayout(source, paintCopy, width, Layout.Alignment.AlignNormal, mSpacingMult, mSpacingAdd, false);
                return layout.Height;
            }
        }
    }
